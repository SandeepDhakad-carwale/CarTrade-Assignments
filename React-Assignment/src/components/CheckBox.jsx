import React from 'react'
import '../styleSheets/CheckBox.css'
import { useSelector,useDispatch } from 'react-redux'
import { setFuel } from '../redux/actions/carDataActions.js'

const CheckBox = ({content,inactive,amount}) => {
    
     const id = `id-${Date.now()}-${Math.random()}`
      const dispatch = useDispatch();
 
       const { fuel } = useSelector((state) => state.carData);

     const handleChange=(e)=>{
     
       
          let val=1;
         if(e.target.name=="Petrol")
          val=1;
          if(e.target.name=="Diesel")
            val=2;
            if(e.target.name=="Cng")
              val=3;
              if(e.target.name=="Lpg")
                val=4;
             if(e.target.name=="Electric")
                  val=5;
               if(e.target.name=="Hybrid")
                val=6;

      if(e.target.checked){
        dispatch(setFuel([...fuel,val]))
        }
        else{
          const t = fuel.filter(item => item !== val)
          
           dispatch(setFuel(t))
        }
        
     }

  return (
    <div className="checkbox">
    <input type="checkbox" id={id} name={content} onChange={inactive === undefined ? handleChange : undefined}/>
    <label htmlFor={id}>{`${content} `}
        {amount?`(${amount})`:""}
    </label>
</div>
  )
}

export default CheckBox