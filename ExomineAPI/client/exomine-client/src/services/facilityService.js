import { baseURL } from "./colonyMineralService";

export const getAllFacilities = async () => {
  const response = await fetch(`${baseURL}/facilities`);
  if (!response.ok) throw new Error("Failed to fetch facilities.");
  return response.json();
};

export const getFacilityById = async (id) => {
  const response = await fetch(`${baseURL}/facilities/${id}`);
  if (!response.ok) throw new Error(`Facility with ID ${id} not found.`);
  return response.json();
};
