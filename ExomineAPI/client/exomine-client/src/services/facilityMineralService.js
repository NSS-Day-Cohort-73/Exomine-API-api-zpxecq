import { baseURL } from "./colonyMineralService";

export const getAllFacilityMinerals = async () => {
  const response = await fetch(`${baseURL}/facilityMinerals`);
  if (!response.ok) throw new Error("Failed to fetch facility minerals.");
  return response.json();
};

export const getExpandedFacilityMinerals = async (facilityId = null) => {
  const params = new URLSearchParams({ _expand: "facility,mineral" });
  if (facilityId) params.append("facilityId", facilityId);
  const response = await fetch(
    `${baseURL}/facilityMinerals?${params.toString()}`
  );
  if (!response.ok)
    throw new Error("Failed to fetch expanded facility minerals.");
  return response.json();
};

export const getFacilityMineralById = async (id) => {
  const response = await fetch(`${baseURL}/facilityMinerals/${id}`);
  if (!response.ok)
    throw new Error(`Facility mineral with ID ${id} not found.`);
  return response.json();
};

export const createFacilityMineral = async (newFacilityMineral) => {
  const response = await fetch(`${baseURL}/facilityMinerals`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newFacilityMineral),
  });
  if (!response.ok) throw new Error("Failed to create facility mineral.");
  return response.json();
};

export const updateFacilityMineral = async (id, updatedFacilityMineral) => {
  const response = await fetch(`${baseURL}/facilityMinerals/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(updatedFacilityMineral),
  });
  if (!response.ok)
    throw new Error(`Failed to update facility mineral with ID ${id}.`);
  return response.json();
};
