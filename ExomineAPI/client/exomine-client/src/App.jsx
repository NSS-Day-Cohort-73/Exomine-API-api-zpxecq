import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { useState, useEffect } from "react";
import GovernorAndFacilitySelectorContainer from "./components/GovernorAndFacilitySelectorContainer";
import ColonyMineralsDisplay from "./components/ColonyMineralsDisplay";
import FacilityMineralsDisplay from "./components/FacilityMineralsDisplay";
import SpaceCart from "./components/SpaceCart";
import { getAllGovernors } from "./services/governorService";
import { getAllFacilities } from "./services/facilityService";
import { getColonyByGovernorId } from "./services/colonyService";
import {
  getMineralsByGovernorId,
  getMineralsByFacilityId,
} from "./services/mineralService";
import { baseURL } from "./services/colonyMineralService";

function App() {
  // Shared state
  const [governors, setGovernors] = useState([]);
  const [facilities, setFacilities] = useState([]);
  const [selectedGovernor, setSelectedGovernor] = useState(null);
  const [selectedFacility, setSelectedFacility] = useState(null);
  const [colony, setColony] = useState({});
  const [colonyMinerals, setColonyMinerals] = useState([]);
  const [facilityMinerals, setFacilityMinerals] = useState([]);
  const [selectedMineralId, setSelectedMineralId] = useState(null);

  // Fetch data on mount
  useEffect(() => {
    const fetchData = async () => {
      try {
        const fetchedGovernors = await getAllGovernors();
        const fetchedFacilities = await getAllFacilities();
        setGovernors(fetchedGovernors.filter((g) => g.active));
        setFacilities(fetchedFacilities.filter((f) => f.active));
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, []);

  // Fetch related data when selectedGovernor changes
  useEffect(() => {
    const fetchGovernorData = async () => {
      if (!selectedGovernor) {
        setColony({});
        setColonyMinerals([]);
        return;
      }

      try {
        const colony = await getColonyByGovernorId(selectedGovernor.id);
        setColony(colony);

        const minerals = await getMineralsByGovernorId(selectedGovernor.id);
        setColonyMinerals(minerals);
      } catch (error) {
        console.error("Error fetching colony or minerals:", error);
        setColony({});
        setColonyMinerals([]);
      }
    };

    fetchGovernorData();
  }, [selectedGovernor]);

  // Fetch related data when selectedFacility changes
  useEffect(() => {
    const fetchFacilityData = async () => {
      if (!selectedFacility) {
        setFacilityMinerals([]);
        setSelectedMineralId(null);
        return;
      }

      try {
        const minerals = await getMineralsByFacilityId(selectedFacility.id);
        setFacilityMinerals(minerals);
        setSelectedMineralId(null); // Reset mineral selection when facility changes
      } catch (error) {
        console.error("Error fetching facility minerals:", error);
        setFacilityMinerals([]);
        setSelectedMineralId(null);
      }
    };

    fetchFacilityData();
  }, [selectedFacility]);

  // Handle mineral selection
  const handleMineralSelect = (mineralId) => {
    setSelectedMineralId(mineralId);
  };

  const handlePurchase = async (governorId, facilityId, mineralId) => {
    try {
      const params = new URLSearchParams({
        governorId: governorId,
        facilityId: facilityId,
        mineralId: mineralId,
      });

      const response = await fetch(`${baseURL}/purchase?${params.toString()}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
      });

      if (!response.ok) {
        const error = await response.text();
        throw new Error(error);
      }

      const result = await response.json();
      alert(result);

      // Fetch updated state from the backend
      const updatedColonyMinerals = await getMineralsByGovernorId(governorId);
      const updatedFacilityMinerals = await getMineralsByFacilityId(facilityId);

      // Update the local state to reflect changes
      setColonyMinerals(updatedColonyMinerals);
      setFacilityMinerals(updatedFacilityMinerals);
    } catch (error) {
      alert(`Purchase failed: ${error.message}`);
    }
  };

  return (
    <div className="container">
      <div className="row text-primary"><h1>Exomine</h1></div>
      <div className="row">
        {/* Governor and Facility Selector */}
        <GovernorAndFacilitySelectorContainer
          governors={governors}
          facilities={facilities}
          selectedGovernor={selectedGovernor}
          selectedFacility={selectedFacility}
          onGovernorChange={(id) =>
            setSelectedGovernor(governors.find((g) => g.id === parseInt(id)))
          }
          onFacilityChange={(id) =>
            setSelectedFacility(facilities.find((f) => f.id === parseInt(id)))
          }
          className="col-xs-11 col-md-5 m-2 box-container"
        />

        {/* Colony Minerals Display */}
        <ColonyMineralsDisplay
          colony={colony}
          colonyMinerals={colonyMinerals}
          className="col-xs-11 col-md-5 m-2 box-container"
        />

        {/* Facility Minerals Display */}
        <FacilityMineralsDisplay
          facilityMinerals={facilityMinerals}
          onMineralSelect={handleMineralSelect}
          className="col-xs-11 col-md-5 m-2 box-container"
        />

        {/* Space Cart */}
        <SpaceCart
          selectedGovernor={selectedGovernor}
          selectedFacility={selectedFacility}
          selectedMineral={facilityMinerals.find(
            (mineral) => mineral.id === selectedMineralId
          )}
          onPurchase={handlePurchase}
          className="col-xs-11 col-md-5 m-2 box-container"
        />
      </div>
    </div>
  );
}

export default App;
