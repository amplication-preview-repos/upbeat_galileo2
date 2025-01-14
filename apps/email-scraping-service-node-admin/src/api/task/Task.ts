export type Task = {
  createdAt: Date;
  id: string;
  scheduledAt: Date | null;
  status?: "Option1" | null;
  updatedAt: Date;
  url: string | null;
};
