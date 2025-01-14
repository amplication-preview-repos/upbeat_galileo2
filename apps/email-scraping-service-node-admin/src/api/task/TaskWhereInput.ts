import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type TaskWhereInput = {
  id?: StringFilter;
  scheduledAt?: DateTimeNullableFilter;
  status?: "Option1";
  url?: StringNullableFilter;
};
