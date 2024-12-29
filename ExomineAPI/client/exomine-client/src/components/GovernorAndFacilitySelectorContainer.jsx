const GovernorAndFacilitySelectorContainer = ({
  governors,
  facilities,
  selectedGovernor,
  selectedFacility,
  onGovernorChange,
  onFacilityChange,
  className,
}) => {
  return (
    <div className={className}>
      <div>
        <label htmlFor="governor-select">Select Governor:</label>
        <select
          id="governor-select"
          value={selectedGovernor?.id || ""}
          onChange={(e) => onGovernorChange(e.target.value)}
        >
          <option value="">-- Choose a Governor --</option>
          {governors.map((governor) => (
            <option key={governor.id} value={governor.id}>
              {governor?.name}
            </option>
          ))}
        </select>
      </div>

      <div className="mt-3">
        <label htmlFor="facility-select">Select Facility:</label>
        <select
          id="facility-select"
          value={selectedFacility?.id || ""}
          onChange={(e) => onFacilityChange(e.target.value)}
        >
          <option value="">-- Choose a Facility --</option>
          {facilities.map((facility) => (
            <option key={facility.id} value={facility.id}>
              {facility?.name}
            </option>
          ))}
        </select>
      </div>
    </div>
  );
};

export default GovernorAndFacilitySelectorContainer;
