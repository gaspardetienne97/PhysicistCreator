import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import {Link} from 'react-router-dom'
import Typography from '@material-ui/core/Typography'


const styles = theme => ({
    homeGrid: {
        display: 'grid',
        gridTemplateColumns: 'auto auto auto',
        gridTemplateRows: 'auto auto auto',
        gridGap: `${theme.spacing.unit * 3}px`,
        backgroundColor: theme.palette.secondary.main,
        height: '100%',
        width: '100%'
    },
    logo: {
        border: '' + theme.palette.primary.dark + ' solid 1%',
        gridArea: '1 / 2 / span 1 / span 1',
        backgroundColor: theme.palette.primary.light,
        borderRadius: '100%'
    },
    description: {
        gridArea: '2 / 2 / span 1 / span 1',
        margin: theme.spacing.unit,
    },
});


class Home extends Component {

    render() {
        const {classes} = this.props;
        return (
            <div className={classes.homeGrid}>
                <div className={classes.logo}>
                    logo goes here!
                </div>
                <div className={classes.description}>
                    <Typography variant="body1">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Assumenda distinctio
                        doloremque ducimus esse hic, illo incidunt neque perspiciatis quod repellat, repudiandae
                        rerum sit vitae. Aut incidunt inventore iste molestiae voluptatum?
                    </Typography>
                    <Link to='/gallery'>
                        <Button variant="contained" color="primary" className={classes.button}>
                            Get Started!
                        </Button>
                    </Link>
                </div>
            </div>
        );
    }
}


Home.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Home);