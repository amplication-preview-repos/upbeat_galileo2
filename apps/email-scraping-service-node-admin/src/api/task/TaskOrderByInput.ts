import { SortOrder } from "../../util/SortOrder";

export type TaskOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  scheduledAt?: SortOrder;
  status?: SortOrder;
  updatedAt?: SortOrder;
  url?: SortOrder;
};
