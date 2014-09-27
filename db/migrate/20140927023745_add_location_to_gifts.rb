class AddLocationToGifts < ActiveRecord::Migration
  def change
    add_column :gifts, :location, :string 
  end
end
