import React from 'react'
import CollectionItem from './CollectionItem'

const Collection = ({title}) => {
  return (
    <section className="collection-grid">
        <div className="container">
            <div className="title">{title}</div>
            <div className="item-collection">
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
                <CollectionItem />
            </div>
        </div>
    </section>
  )
}

export default Collection