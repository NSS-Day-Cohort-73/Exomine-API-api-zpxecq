import { baseURL } from "./colonyMineralService";

export const getAllGovernors = async () => {
  const response = await fetch(`${baseURL}/governors`);
  if (!response.ok) throw new Error("Failed to fetch governors.");
  return response.json();
};

export const getExpandedGovernors = async () => {
  const response = await fetch(`${baseURL}/governors?_expand=colony`);
  if (!response.ok) throw new Error("Failed to fetch expanded governors.");
  return response.json();
};

export const getGovernorById = async (id) => {
  const response = await fetch(`${baseURL}/governors/${id}`);
  if (!response.ok) throw new Error(`Governor with ID ${id} not found.`);
  return response.json();
};
