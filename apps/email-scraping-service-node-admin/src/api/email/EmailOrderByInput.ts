import { SortOrder } from "../../util/SortOrder";

export type EmailOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  scrapedDate?: SortOrder;
  sourceUrl?: SortOrder;
  updatedAt?: SortOrder;
};
