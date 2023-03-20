import React from 'react'
import CollectionItem from './CollectionItem';

const TwoColumnCollection = () => {
  return (
    <section className="collection-twocolumns">
        <div className="column bg-gray">
            <div class="content">
                <h1>2 FOR USD $29</h1>
                <button className="btn-white">NEW PRODUCTS</button>
            </div>
        </div>
        <div className="column item-collection">
               <CollectionItem /> 
               <CollectionItem /> 
               <CollectionItem /> 
               <CollectionItem /> 
               <CollectionItem /> 
               <CollectionItem /> 
        </div>
    </section>
  )
}

export default TwoColumnCollection