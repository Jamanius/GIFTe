class Gift < ActiveRecord::Base
  # Similar to whitespace get the whole team on one type of tab
  # I would suggest 2 spaces for a tab. Seems like a small thing
  # but different editors show tabs differently and it messes
  # with indentation making the code harder to read.
	validates :title, presence: true
  validates :description, presence: true

	belongs_to :user
 	has_many :requests

end
