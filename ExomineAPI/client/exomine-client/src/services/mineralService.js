import { baseURL } from "./colonyMineralService";

export const getAllMinerals = async () => {
  const response = await fetch(`${baseURL}/minerals`);
  if (!response.ok) throw new Error("Failed to fetch minerals.");
  return response.json();
};

export const getMineralById = async (id) => {
  const response = await fetch(`${baseURL}/minerals/${id}`);
  if (!response.ok) throw new Error(`Mineral with ID ${id} not found.`);
  return response.json();
};

export const getMineralsByGovernorId = async (governorId) => {
  const response = await fetch(`${baseURL}/minerals/governor/${governorId}`);
  if (!response.ok)
    throw new Error(`Minerals for governor ID ${governorId} not found.`);
  return response.json();
};

export const getMineralsByFacilityId = async (facilityId) => {
  const response = await fetch(`${baseURL}/minerals/facility/${facilityId}`);
  if (!response.ok)
    throw new Error(`Minerals for facility ID ${facilityId} not found.`);
  return response.json();
};
