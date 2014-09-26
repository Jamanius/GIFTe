class Request < ActiveRecord::Base
  belongs_to :user_id
  belongs_to :gift_id
end
