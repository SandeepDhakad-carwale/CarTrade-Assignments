import React from 'react'
import '../styleSheets/sort.css'
import { useDispatch } from "react-redux";
import { setSortBy } from '../redux/actions/carDataActions.js'



function Sort() {

    const dispatch=useDispatch();

    const handleSort=(e)=>{
        dispatch(setSortBy(e.target.value))
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