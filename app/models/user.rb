class User < ActiveRecord::Base
  # Include default devise modules. Others available are:
  # :confirmable, :lockable, :timeoutable and :omniauthable
  	devise :database_authenticatable, :registerable,
         :recoverable, :rememberable, :trackable, :validatable

    has_many :gifts
    has_many :requests

  	def full_name
  		"#{first_name} #{last_name}"
  	end 

    def has_requested?(gift)
      requests.where(gift_id: gift.id).exists?
    end 

    def request_for(gift)
      requests.where(gift_id: gift.id).first
    end 
         
end
