using ExomineAPI.Models.DTOs;
using ExomineAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Register services for dependency injection
builder.Services.AddSingleton<GovernorService>();
builder.Services.AddSingleton<ColonyService>();
builder.Services.AddSingleton<FacilityService>();
builder.Services.AddSingleton<MineralService>();
builder.Services.AddSingleton<FacilityMineralService>();
builder.Services.AddSingleton<ColonyMineralService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

// Governor endpoints
app.MapGet(
        "/governors",
        (GovernorService governorService, string? _expand) =>
        {
            // Check if the _expand query parameter is set to "colony"
            var includeColony = _expand == "colony";

            // Pass the includeColony flag to the service
            var governors = governorService.GetAllGovernors(includeColony);

            return Results.Ok(governors);
        }
    )
    .WithName("GetAllGovernors")
    .WithOpenApi();
app.MapGet(
        "/governors/{id}",
        (GovernorService governorService, int id) =>
        {
            // Get the governor by ID with colony always expanded
            var governor = governorService.GetGovernorById(id);

            // Return the governor or a 404 if not found
            return governor != null
                ? Results.Ok(governor)
                : Results.NotFound($"Governor with id {id} not found.");
        }
    )
    .WithName("GetGovernorById")
    .WithOpenApi();

// Colony endpoints
app.MapGet(
        "/colonies/{id}",
        (ColonyService colonyService, int id) =>
        {
            var result = colonyService.GetColonyById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetColonyById")
    .WithOpenApi();

// Facility endpoints
app.MapGet("/facilities", (FacilityService facilityService) => facilityService.GetAllFacilities())
    .WithName("GetAllFacilities")
    .WithOpenApi();

app.MapGet(
        "/facilities/{id}",
        (FacilityService facilityService, int id) =>
        {
            var result = facilityService.GetFacilityById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetFacilityById")
    .WithOpenApi();

// Mineral endpoints
app.MapGet("/minerals", (MineralService mineralService) => mineralService.GetAllMinerals())
    .WithName("GetAllMinerals")
    .WithOpenApi();

app.MapGet(
        "/minerals/{id}",
        (MineralService mineralService, int id) =>
        {
            var result = mineralService.GetMineralById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetMineralById")
    .WithOpenApi();

app.MapGet(
        "/minerals/governor/{governorId}",
        (MineralService mineralService, int governorId) =>
        {
            var result = mineralService.GetMineralsByGovernorId(governorId);
            return result != null && result.Any() ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetMineralsByGovernorId")
    .WithOpenApi();

app.MapGet(
        "/minerals/facility/{facilityId}",
        (MineralService mineralService, int facilityId) =>
        {
            var result = mineralService.GetMineralsByFacilityId(facilityId);
            return result != null && result.Any() ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetMineralsByFacilityId")
    .WithOpenApi();

// Colony endpoints
app.MapGet(
        "/colonies/governor/{governorId}",
        (ColonyService colonyService, int governorId) =>
        {
            var result = colonyService.GetColonyByGovernorId(governorId);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetColonyByGovernorId")
    .WithOpenApi();

// FacilityMineral endpoints

app.MapGet(
        "/facilityMinerals",
        (FacilityMineralService facilityMineralService, string? _expand, int? facilityId) =>
        {
            // Determine which expansions are requested
            var expandFacility = _expand?.Contains("facility") == true;
            var expandMineral = _expand?.Contains("mineral") == true;

            // Get the data from the service
            var facilityMinerals = facilityMineralService.GetAllFacilityMinerals(
                expandFacility,
                expandMineral,
                facilityId
            );

            return Results.Ok(facilityMinerals);
        }
    )
    .WithName("GetAllFacilityMinerals")
    .WithOpenApi();

app.MapGet(
        "/facilityMinerals/{id}",
        (FacilityMineralService facilityMineralService, int id) =>
        {
            var facilityMineral = facilityMineralService.GetFacilityMineralById(id);

            if (facilityMineral == null)
            {
                return Results.NotFound($"Facility mineral with id {id} not found.");
            }

            return Results.Ok(facilityMineral);
        }
    )
    .WithName("GetFacilityMineralById")
    .WithOpenApi();

app.MapPut(
        "/facilityMinerals/{id}",
        (
            FacilityMineralService facilityMineralService,
            int id,
            FacilityMineralDTO updatedFacilityMineral
        ) =>
        {
            if (updatedFacilityMineral == null || updatedFacilityMineral.Id != id)
            {
                return Results.BadRequest("Invalid data.");
            }

            var updatedMineral = facilityMineralService.UpdateFacilityMineral(
                id,
                updatedFacilityMineral
            );

            if (updatedMineral == null)
            {
                return Results.NotFound($"Facility mineral with id {id} not found.");
            }

            return Results.Ok(updatedMineral); // Return the updated object
        }
    )
    .WithName("UpdateFacilityMineral")
    .WithOpenApi();

app.MapPost(
        "/facilityMinerals",
        (FacilityMineralService facilityMineralService, FacilityMineralDTO newFacilityMineral) =>
        {
            if (newFacilityMineral == null)
            {
                return Results.BadRequest("Invalid data.");
            }

            var createdMineral = facilityMineralService.CreateFacilityMineral(newFacilityMineral);

            return Results.Created($"/facilityMinerals/{createdMineral.Id}", createdMineral);
        }
    )
    .WithName("CreateFacilityMineral")
    .WithOpenApi();

// ColonyMineral endpoints
app.MapGet(
        "/colonyMinerals",
        (ColonyMineralService colonyMineralService, string? _expand, int? colonyId) =>
        {
            // Determine which expansions are requested
            var expandColony = _expand?.Contains("colony") == true;
            var expandMineral = _expand?.Contains("mineral") == true;

            // Get the data from the service
            var colonyMinerals = colonyMineralService.GetAllColonyMinerals(
                expandColony,
                expandMineral,
                colonyId
            );

            return Results.Ok(colonyMinerals);
        }
    )
    .WithName("GetAllColonyMinerals")
    .WithOpenApi();

app.MapGet(
        "/colonyMinerals/{id}",
        (ColonyMineralService colonyMineralService, int id) =>
        {
            var result = colonyMineralService.GetColonyMineralById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetColonyMineralById")
    .WithOpenApi();

app.MapPut(
        "/colonyMinerals/{id}",
        (
            ColonyMineralService colonyMineralService,
            int id,
            ColonyMineralDTO updatedColonyMineral
        ) =>
        {
            if (updatedColonyMineral == null || updatedColonyMineral.Id != id)
            {
                return Results.BadRequest("Invalid data.");
            }

            var updatedMineral = colonyMineralService.UpdateColonyMineral(id, updatedColonyMineral);

            if (updatedMineral == null)
            {
                return Results.NotFound($"Colony mineral with id {id} not found.");
            }

            return Results.Ok(updatedMineral); // Return the updated object
        }
    )
    .WithName("UpdateColonyMineral")
    .WithOpenApi();

app.MapPost(
        "/colonyMinerals",
        (ColonyMineralService colonyMineralService, ColonyMineralDTO newColonyMineral) =>
        {
            if (newColonyMineral == null)
            {
                return Results.BadRequest("Invalid data.");
            }

            var createdMineral = colonyMineralService.CreateColonyMineral(newColonyMineral);

            return Results.Created($"/colonyMinerals/{createdMineral.Id}", createdMineral);
        }
    )
    .WithName("CreateColonyMineral")
    .WithOpenApi();

//Purchase Endpoint
app.MapPost(
        "/purchase",
        (
            ColonyMineralService colonyMineralService,
            FacilityMineralService facilityMineralService,
            int governorId,
            int facilityId,
            int mineralId
        ) =>
        {
            try
            {
                // Perform the purchase logic
                var result = colonyMineralService.HandlePurchase(governorId, facilityId, mineralId);

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    )
    .WithName("PurchaseMineral")
    .WithOpenApi();

app.Run();
