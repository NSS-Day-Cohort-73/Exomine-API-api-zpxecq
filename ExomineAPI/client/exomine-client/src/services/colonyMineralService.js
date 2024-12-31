export const baseURL = "https://localhost:7038";

export const getAllColonyMinerals = async () => {
  const response = await fetch(`${baseURL}/colonyMinerals`);
  if (!response.ok) throw new Error("Failed to fetch colony minerals.");
  return response.json();
};

export const getExpandedColonyMinerals = async (colonyId = null) => {
  const params = new URLSearchParams({ _expand: "colony,mineral" });
  if (colonyId) params.append("colonyId", colonyId);
  const response = await fetch(
    `${baseURL}/colonyMinerals?${params.toString()}`
  );
  if (!response.ok)
    throw new Error("Failed to fetch expanded colony minerals.");
  return response.json();
};

export const getColonyMineralById = async (id) => {
  const response = await fetch(`${baseURL}/colonyMinerals/${id}`);
  if (!response.ok) throw new Error(`Colony mineral with ID ${id} not found.`);
  return response.json();
};

export const createColonyMineral = async (newColonyMineral) => {
  const response = await fetch(`${baseURL}/colonyMinerals`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newColonyMineral),
  });
  if (!response.ok) throw new Error("Failed to create colony mineral.");
  return response.json();
};

export const updateColonyMineral = async (id, updatedColonyMineral) => {
  const response = await fetch(`${baseURL}/colonyMinerals/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(updatedColonyMineral),
  });
  if (!response.ok)
    throw new Error(`Failed to update colony mineral with ID ${id}.`);
  return response.json();
};
