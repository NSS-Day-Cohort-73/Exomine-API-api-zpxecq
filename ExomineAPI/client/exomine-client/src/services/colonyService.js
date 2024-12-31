import { baseURL } from "./colonyMineralService";

export const getColonyById = async (id) => {
  const response = await fetch(`${baseURL}/colonies/${id}`);
  if (!response.ok) throw new Error(`Colony with ID ${id} not found.`);
  return response.json();
};

export const getColonyByGovernorId = async (governorId) => {
  const response = await fetch(`${baseURL}/colonies/governor/${governorId}`);
  if (!response.ok)
    throw new Error(`Colony for governor ID ${governorId} not found.`);
  return response.json();
};
