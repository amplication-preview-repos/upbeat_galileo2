import * as React from "react";
import {
  Edit,
  SimpleForm,
  EditProps,
  DateTimeInput,
  TextInput,
} from "react-admin";

export const EmailEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <DateTimeInput label="scrapedDate" source="scrapedDate" />
        <TextInput label="sourceUrl" source="sourceUrl" />
      </SimpleForm>
    </Edit>
  );
};
