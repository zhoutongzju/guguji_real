-- Add/modify columns 
alter table T_REPORT_QUEUE add read_verify_flag char(1);
-- Add comments to the columns 
comment on column T_REPORT_QUEUE.read_verify_flag
  is '是否上传了报告';

