RSpec.describe Gift, :type => :model do

	it "initializes an instance of Gift" do
 		expect(Gift.new).to be_a(Gift)
	end

end