class GiftsController < ApplicationController
  before_action :set_gift, only: [:show, :edit, :update, :destroy]

  # GET /gifts
  # GET /gifts.json
  def index
    @gifts = Gift.all 
    @gift = Gift.new
    @user = User.new

    # respond_to // still see html page. User goes to /gifts, renders gifts view, then JS will ask server for gifts json 
    respond_to do |format|
      format.html 
      format.json { render json: @gifts }
    end    

  end

  # GET /gifts/1
  # GET /gifts/1.json
  def show
    @gift = Gift.find(params[:id])
    respond_to do |format|
      format.html 
      format.json { render json: @gift }
    end 
  end

  # GET /gifts/new
  def new
    return redirect_to new_user_session_path unless current_user
    @gift = Gift.new
  end

  # GET /gifts/1/edit
  def edit
    return redirect_to new_user_session_path unless current_user == @gift.user 
  end

  # POST /gifts
  # POST /gifts.json
  def create
    return redirect_to new_user_session_path unless current_user
    @gift = Gift.new(gift_params)
    @gift.user = current_user 

    respond_to do |format|
      if @gift.save
        format.html { redirect_to dashboard_listed_path, notice: 'Gift was successfully created.' }
        format.json { render :show, status: :created, location: @gift }
      else
        format.html { render :new }
        format.json { render json: @gift.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /gifts/1
  # PATCH/PUT /gifts/1.json
  def update
    return redirect_to new_user_session_path unless current_user == @gift.user 
    respond_to do |format|
      if @gift.update(gift_params)
        format.html { redirect_to @gift, notice: 'Gift was successfully updated.' }
        format.json { render :show, status: :ok, location: @gift }
      else
        format.html { render :edit }
        format.json { render json: @gift.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /gifts/1
  # DELETE /gifts/1.json
  def destroy
    @gift.destroy
    respond_to do |format|
      format.html { redirect_to gifts_url, notice: 'Gift was successfully destroyed.' }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_gift
      @gift = Gift.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def gift_params
      params.require(:gift).permit(:title, :description, :type, :comments, :image)
    end
end
