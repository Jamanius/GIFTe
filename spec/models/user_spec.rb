RSpec.describe User, :type => :model do

	it "initializes an instance of User" do
 		expect(User.new).to be_a(User)
	end

	it "has a full name" do
	    fox = User.create!(first_name: "Fox", last_name: "Mayfield", email: "f@o.x", password: "abcdefgh")
	    expect(fox.full_name).to eq("Fox Mayfield")
	end

end