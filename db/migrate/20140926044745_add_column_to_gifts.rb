class AddColumnToGifts < ActiveRecord::Migration
  def change
    add_column :gifts, :status, :string 
  end
end
