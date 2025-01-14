import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  DateTimeInput,
  TextInput,
} from "react-admin";

export const EmailCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <DateTimeInput label="scrapedDate" source="scrapedDate" />
        <TextInput label="sourceUrl" source="sourceUrl" />
      </SimpleForm>
    </Create>
  );
};
