class ProfilesController < ApplicationController
  def show
    # @user = User.find_by_profile_name(params[:id])
    @user = User.find(params[:id])
    if @user 
      @gifts = @user.gifts.all 
      render action: :show 
    else 
      render file: 'public/404', status: 404, formats: [:html]
    end 

  end
end
