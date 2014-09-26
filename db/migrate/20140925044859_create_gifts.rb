class CreateGifts < ActiveRecord::Migration
  def change
    create_table :gifts do |t|
      t.string :title
      t.text :description
      t.string :type
      t.text :comments
      t.string :image
  

      t.timestamps
    end
  end
end
