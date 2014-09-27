class RenameTypeFromGifts < ActiveRecord::Migration
  def change
    remove_column :gifts, :type 
    add_column :gifts, :gifts_type, :string 
  end
end
