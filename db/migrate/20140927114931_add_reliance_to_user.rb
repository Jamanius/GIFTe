class AddRelianceToUser < ActiveRecord::Migration
  def change
    add_column :users, :reliance, :integer    
  end
end
