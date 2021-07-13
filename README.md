# odata-service

# get EntitySet
https://localhost:5001/odata/Products

# filter
https://localhost:5001/odata/Products?$filter=Name%20eq%20%27Box%27

# function 
https://localhost:5001/odata/GetByName(Name='Box')

# function + filter
https://localhost:5001/odata/GetByName(Name='Box')?$filter=Id%20eq%202