import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type EmailWhereInput = {
  id?: StringFilter;
  scrapedDate?: DateTimeNullableFilter;
  sourceUrl?: StringNullableFilter;
};
