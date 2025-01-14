import { Task as TTask } from "../api/task/Task";

export const TASK_TITLE_FIELD = "url";

export const TaskTitle = (record: TTask): string => {
  return record.url?.toString() || String(record.id);
};
