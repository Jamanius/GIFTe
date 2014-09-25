json.array!(@gifts) do |gift|
  json.extract! gift, :id, :title, :description, :type, :comments
  json.url gift_url(gift, format: :json)
end
