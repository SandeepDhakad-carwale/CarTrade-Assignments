
const sortCars=(cars,sortBy)=>{
    const arr=[...cars]
  if(sortBy=="price-low to high"){
    arr.sort((a, b) => a.priceNumeric - b.priceNumeric);
   
  }
  else if(sortBy=="price-high to low")
     arr.sort((a,b)=> b.priceNumeric-a.priceNumeric);

  return arr;
}

export default sortCars;