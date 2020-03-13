//https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio#configure-mongodb

db.createCollection('Users')

db.Users.insertMany([
{
    'Username': 'Andre', 
    'Password': '456', 
    'Role': 'DevMaster'
},
{
    'Username': 'Carlos', 
    'Password': '789', 
    'Role': 'DevBack'
}])

db.Users.find({}).pretty()