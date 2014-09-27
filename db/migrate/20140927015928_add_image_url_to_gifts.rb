class AddImageUrlToGifts < ActiveRecord::Migration
  def change
    add_column :gifts, :image_url, :string
  end
end
