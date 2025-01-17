import React from 'react'
import '../styleSheets/sort.css'
import { useSelector,useDispatch } from "react-redux";
import { setfilteredCars } from '../redux/actions/carDataActions.js'



function Sort() {

    const dispatch=useDispatch();
    const { filteredCars} = useSelector((state) => state.carData);

    const handleSort=(e)=>{
      let sortedArr=filteredCars;
        if(e.target.value=="price-low to high")
             sortedArr = filteredCars.sort((a, b) => Number(a.priceNumeric) - Number(b.priceNumeric));
          else{
            sortedArr = filteredCars.sort((a, b) => Number(b.priceNumeric) - Number(a.priceNumeric));
          }
     
        
        dispatch(setfilteredCars(sortedArr))
    }

  return (
   <div className="sortContainer">
     <div className="">
        <label>Sort By:</label>
       <select id='sortBy' className='sortBy' onChange={handleSort} >
         <option value="default">default</option>
         <option value="price-low to high">Price-low to high</option>
         <option value="price-high to low">Price-high to low</option>
       </select>
     </div>
   </div>
  )
}

export default Sort