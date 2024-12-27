using ExomineAPI.Models.DTOs;
using ExomineAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//Colony Endpoints

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

// Facility Mineral endpoints
app.MapGet(
        "/facility-minerals",
        (FacilityMineralService facilityMineralService) =>
            facilityMineralService.GetAllFacilityMinerals()
    )
    .WithName("GetAllFacilityMinerals")
    .WithOpenApi();

app.MapGet(
        "/facility-minerals/{id}",
        (FacilityMineralService facilityMineralService, int id) =>
        {
            var result = facilityMineralService.GetFacilityMineralById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetFacilityMineralById")
    .WithOpenApi();

app.MapPut(
        "/facility-minerals/{id}",
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

// Colony Mineral endpoints
// Colony Mineral endpoints
app.MapGet(
        "/colony-minerals",
        (ColonyMineralService colonyMineralService) => colonyMineralService.GetAllColonyMinerals()
    )
    .WithName("GetAllColonyMinerals")
    .WithOpenApi();

app.MapGet(
        "/colony-minerals/{id}",
        (ColonyMineralService colonyMineralService, int id) =>
        {
            var result = colonyMineralService.GetColonyMineralById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }
    )
    .WithName("GetColonyMineralById")
    .WithOpenApi();

app.MapPut(
        "/colony-minerals/{id}",
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
        "/colony-minerals",
        (ColonyMineralService colonyMineralService, ColonyMineralDTO newColonyMineral) =>
        {
            if (newColonyMineral == null)
            {
                return Results.BadRequest("Invalid data.");
            }

            var createdMineral = colonyMineralService.CreateColonyMineral(newColonyMineral);

            return Results.Created($"/colony-minerals/{createdMineral.Id}", createdMineral);
        }
    )
    .WithName("CreateColonyMineral")
    .WithOpenApi();

app.Run();
