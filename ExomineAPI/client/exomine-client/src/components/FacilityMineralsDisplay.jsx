

const FacilityMineralsDisplay = ({
  selectedFacility,
  facilityMinerals,
  className,
  onMineralSelect,
}) => {
  return (
    <div className={className}>
      {/* Display the facility name */}
      <h2>
        {selectedFacility?.name
          ? `${selectedFacility?.name} Minerals`
          : "Facility Minerals"}
      </h2>

      {/* Display the minerals list with radios */}
      {facilityMinerals.length > 0 ? (
        <ul>
          {facilityMinerals.map(({ id, quantity, name }) => (
            <li key={id}>
              <input
                type="radio"
                name="facilityMineral"
                value={id}
                onChange={() => onMineralSelect(id)}
                disabled={!quantity}
              />
              {quantity > 0
                ? `${quantity} tons of ${name}`
                : `Out of stock: ${name}`}
            </li>
          ))}
        </ul>
      ) : (
        <p>
          {selectedFacility?.name
            ? "No minerals available."
            : "Select a facility to view minerals."}
        </p>
      )}
    </div>
  );
};

export default FacilityMineralsDisplay;
