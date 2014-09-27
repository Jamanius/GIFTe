class LandingController < ApplicationController

  def index 
    if current_user 
      redirect_to gifts_path
    else 
      render layout: "landing"
    end   
  end 
  
end
