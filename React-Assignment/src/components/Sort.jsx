import React from 'react'
import '../styleSheets/sort.css'
import { useSelector,useDispatch } from "react-redux";
import { setfilteredCars } from '../redux/actions/carDataActions.js'



function Sort() {

    const dispatch=useDispatch();
    const { filteredCars} = useSelector((state) => state.carData);

    const handleSort=(e)=>{
        if(e.target.value=="price"){
            console.log(filteredCars)
            let sortedArr = filteredCars.sort((a, b) => Number(a.priceNumeric) - Number(b.priceNumeric));

       dispatch(setfilteredCars(sortedArr))
        }
    }

  return (
   <div className="sortContainer">
     <div className="">
        <label>Sort By:</label>
       <select id='sortBy' className='sortBy' onChange={handleSort} >
         <option value="default">default</option>
         <option value="price">By Price</option>
       </select>
     </div>
   </div>
  )
}

export default Sort