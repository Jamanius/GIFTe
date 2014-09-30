class Request < ActiveRecord::Base
  validates :message, presence: true
  
  belongs_to :user
  belongs_to :gift

# // only allow one request (per gift) for each user
  validates_uniqueness_of :user, scope: :gift 
end
