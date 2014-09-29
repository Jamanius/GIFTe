class Request < ActiveRecord::Base
  belongs_to :user
  belongs_to :gift
  # Should add validations to make sure the
  # foreign keys have been added
end
