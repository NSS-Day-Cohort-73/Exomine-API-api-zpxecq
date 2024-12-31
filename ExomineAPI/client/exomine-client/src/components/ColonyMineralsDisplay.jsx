const ColonyMineralsDisplay = ({ colony, colonyMinerals, className }) => {
  return (
    <div className={className}>
      {/* Display the colony name */}
      <h2>{colony?.name ? colony?.name : "Colony Minerals"}</h2>

      {/* Display the minerals list */}
      {colonyMinerals.length > 0 ? (
        <ul>
          {colonyMinerals.map((mineral) => (
            <li key={mineral.id}>
              {mineral.name}: {mineral.quantity} tons
            </li>
          ))}
        </ul>
      ) : (
        <p>
          {colony?.name
            ? "No minerals available."
            : "Select a governor to view minerals."}
        </p>
      )}
    </div>
  );
};

export default ColonyMineralsDisplay;
