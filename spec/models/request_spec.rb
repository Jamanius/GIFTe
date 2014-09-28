RSpec.describe Request, :type => :model do

	it "initializes an instance of Request" do
 		expect(Request.new).to be_a(Request)
	end

end