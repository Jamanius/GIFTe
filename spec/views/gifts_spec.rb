require 'rails_helper'

RSpec.describe "gifts/show", :type => :view do
  it "displays the gift detailed information" do
    assign(:gift, Gift.new(:id => 1, :title => "Lizard"))
    render
    expect(rendered).to include("Lizard")
  end
end