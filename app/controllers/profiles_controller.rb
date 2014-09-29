class ProfilesController < ApplicationController
  def show
    # Don't commit commented out code
    # @user = User.find_by_profile_name(params[:id])
    @user = User.find(params[:id])
    if @user 
      # By default the association will give you all gifts for this user so you
      # don't need to call all after.
      @gifts = @user.gifts.all 
      render action: :show 
    else 
      render file: 'public/404', status: 404, formats: [:html]
    end 

  end
end
