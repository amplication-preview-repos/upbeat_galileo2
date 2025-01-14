import { Email as TEmail } from "../api/email/Email";

export const EMAIL_TITLE_FIELD = "sourceUrl";

export const EmailTitle = (record: TEmail): string => {
  return record.sourceUrl?.toString() || String(record.id);
};
