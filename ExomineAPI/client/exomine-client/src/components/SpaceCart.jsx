
const SpaceCart = ({
  selectedGovernor,
  selectedFacility,
  selectedMineral,
  onPurchase,
  className,
}) => {
  const handlePurchaseClick = () => {
    if (selectedGovernor && selectedFacility && selectedMineral) {
      onPurchase(selectedGovernor.id, selectedFacility.id, selectedMineral.id);
    } else {
      alert("Please select a governor, facility, and mineral.");
    }
  };

  return (
    <div className={className}>
      <h2>Space Cart</h2>
      {selectedMineral ? (
        <div>
          <p>{selectedMineral.name}: 1 ton</p>
          <button
            className="btn btn-outline-primary mb-2"
            onClick={handlePurchaseClick}
          >
            Purchase Mineral
          </button>
        </div>
      ) : (
        <p>No mineral selected.</p>
      )}
    </div>
  );
};

export default SpaceCart;
