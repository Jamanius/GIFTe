# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the rake db:seed (or created alongside the db with db:setup).
#
# Examples:
#
#   cities = City.create([{ name: 'Chicago' }, { name: 'Copenhagen' }])
#   Mayor.create(name: 'Emanuel', city: cities.first)
# Gift.create(title:"Eggcups", description: "I don't want these, maybe someone else will", comments:"will leave them in the letterbox")
# Gift.create(title:"Carrots", description: "Yard is overgrown, want to give carrots away", comments:"good for cake")

Gift.create(title:"Carrots", description:"Yummy", location:"Wellington", comments: "Pickup on weekends")
Gift.create(title:"Horse", descritpion:"Friendly and tall", type:"Useable", location:"Auckland", comments:"likes carrots")
Gift.create(title:"babysitting", description:"freebaby sitter", type:"Useable", location:"Wellington", comments:"available on weekends")
Gift.create(title:"shoes", description:"good condition", type:"Wearable", location:"Auckland", comments:"a bit smelly but all good")