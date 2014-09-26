class CreateRequests < ActiveRecord::Migration
  def change
    create_table :requests do |t|
      t.references :user_id, index: true
      t.references :gift_id, index: true

      t.timestamps
    end
  end
end
