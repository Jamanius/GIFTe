class ChangeRequestTableColumnNames < ActiveRecord::Migration
  def change
    rename_column :requests, :user_id_id, :user_id 
    rename_column :requests, :gift_id_id, :gift_id 
  end
end
