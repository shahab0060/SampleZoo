#install modules
#pip install pandas
#import modules
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
#file = pd.read_csv("C:\\Users\\SEYED\\Downloads\\1.csv")
data = {
    "id" : [1,2,3,4,5],
    "createDate" : ["20220101","20210101","20220101","20220103","20220205"],
    "priceEach" : [1231,23232,4232,434242,2323],
    "quantity" : [4,9,8,12,89],
    "productName" : ["laptop","phone","toy","toy","laptop"]
}
file = pd.DataFrame(data)
file.drop_duplicates(inplace=True)
file.dropna(inplace=True)

file['CreateDate'] = pd.to_datetime(file['createDate'])

productsSells = file.groupby('productName')['quantity'].sum()
mostSoldProduct = productsSells.idxmax()
print(f'the most sold product was {mostSoldProduct}')

file['TotalSell'] = file['quantity'] * file["priceEach"]
productPriceSells = file.groupby('productName')['TotalSell'].sum() 
mostProductPriceSell = productPriceSells.idxmax()
print(f"most price is {mostProductPriceSell}")
print(f"with price of {productPriceSells[mostProductPriceSell]}")
file['month'] = file['CreateDate'].dt.month
file['hour'] = file['CreateDate'].dt.hour

sellsByMonth = file.groupby('month')['TotalSell'].sum()
mostSoldMonth = sellsByMonth.idxmax()
print(f'most-sold-month-is-{mostSoldMonth}')

sellsByHour= file.groupby('hour')['TotalSell'].sum()
mostSoldHour = sellsByHour.idxmax()
print(f'most-sold-hour-is-{mostSoldHour}')
plt.bar(sellsByMonth.index, sellsByMonth.values)
plt.xlabel('Month')
plt.ylabel('Total Sales')
plt.title('Total Sales by Month')
plt.show()
