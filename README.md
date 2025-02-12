# Spine scolsis disease detector backend server
To run the backend server you need dotnet-sdk 9 or 8 runtime
run the following after installation:
'''
dotnet ef migrations add intinial
dotnet ef database update
dotnet build
dotnet run
'''
after that go to localhost:5199/swagger 
